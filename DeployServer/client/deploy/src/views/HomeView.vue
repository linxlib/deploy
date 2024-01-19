<template>
  <a-page-header style="border: 0px solid rgb(235, 237, 240); accent-color: red">
    <slot name="title">
      <h2 style="color: white">部署服务</h2>
    </slot>
  </a-page-header>
  <a-list :grid="{ gutter: 24, column: 4 }" :data-source="data">
    <template #renderItem="{ item }">
      <a-list-item>
        <a-card :title="item.name">
          <template #actions>
            <DeploymentUnitOutlined
              style="color: darkturquoise"
              key="deploy"
              @click="deploymentClick(item)"
            />
            <a-popconfirm
              title="确认要重启服务吗?"
              ok-text="重启"
              cancel-text="放弃"
              @confirm="confirmReboot(item.id)"
            >
              <RetweetOutlined style="color: blue" key="reboot" />
            </a-popconfirm>
            <a-popconfirm
              title="确认要关闭服务吗?"
              ok-text="关闭"
              cancel-text="放弃"
              @confirm="confirmClose(item.id)"
            >
              <CloseCircleOutlined style="color: red" key="close" />
            </a-popconfirm>
            <FolderViewOutlined
              style="color: black"
              key="view"
              @click="viewFolder(item.realPath)"
            />
          </template>
          <template #extra>
            <a-flex horizontal gap="small">
              <a @click="editService(item)">编辑</a>
              <a-popconfirm
              title="确认要删除服务吗?"
              ok-text="删除"
              cancel-text="放弃"
              @confirm="confirmDelService(item.id)"
            >
            <a @click="delService(item)">删除</a>
          </a-popconfirm>
              
            </a-flex>
          </template>
          <a-flex vertical>
            <a-flex horizontal gap="small">
              <span>服务名: </span><span>{{ item.serviceName }}</span>
            </a-flex>
            <a-flex horizontal gap="small">
              <span>路径: </span><span>{{ item.realPath }}</span>
            </a-flex>
            <a-flex horizontal gap="small">
              <span>类型: </span><span>{{ item.serviceType }}</span>
            </a-flex>
            <a-flex horizontal gap="small">
              <span>监听: </span><span>{{ item.listenUrl }}</span>
            </a-flex>
            <a-flex horizontal gap="small">
              <span>状态: </span><span :style="item.color">{{ item.status }}</span>
            </a-flex>
          </a-flex>
        </a-card>
      </a-list-item>
    </template>
  </a-list>



  <a-float-button-group trigger="click" type="primary" :style="{ right: '24px' }">
    <template #icon>
      <MenuUnfoldOutlined />
    </template>
    <a-float-button tooltip="切换用户" @click="switchUserClick">
      <template #icon>
        <UserSwitchOutlined />
      </template>
    </a-float-button>
    <a-float-button tooltip="用户管理" @click="userManageClick">
      <template #icon>
        <UserOutlined />
      </template>
    </a-float-button>
  </a-float-button-group>


  <a-modal v-model:open="viewFolderOpen" title="目录查看" footer="">
    <a-flex vertical gap="middle">
      <a-tag>{{ curPath }}</a-tag>
      <a-tag> {{ selectedPath }}</a-tag>
      <a-directory-tree multiple :tree-data="treeData" :load-data="onLoadData" @select="treeSelect">
      </a-directory-tree>
      <a-button @click="selPath" :disabled="isCanSelect">选择</a-button>
    </a-flex>
  </a-modal>

  <a-modal v-model:open="viewIISListOpen" title="IIS服务列表" footer="">
    <a-flex vertical gap="middle">
      <a-tag> 你选择了: {{ selectedIIS.name }}</a-tag>
      <a-list item-layout="horizontal" :data-source="iisList" selectable>
        <template #renderItem="{ item }">
          <a-list-item @click="iisListClick(item)">
            <a-list-item-meta
              :description="item.realPath"
            >
              <template #title>
                <span>{{ item.name }} &lt;== {{ item.listenUrl }}</span>
              </template>
            </a-list-item-meta>
          </a-list-item>
        </template>
      </a-list>

      <a-button @click="selIIS" :disabled="isCanSelect">选择</a-button>
    </a-flex>
  </a-modal>

  <a-modal v-model:open="serviceModalOpen" :title="tt">
    <a-flex horizontal gap="middle">
      <a-flex vertical gap="middle">
        <a-input v-model:value="model.name" placeholder="请输入服务名称"> </a-input>
        <a-input v-model:value="model.serviceName" placeholder="请输入服务名"> </a-input>
        <a-input v-model:value="model.arg" placeholder="请输入参数"> </a-input>
        <a-input v-model:value="model.realPath" placeholder="请输入路径"> </a-input>
        <a-input v-model:value="model.listenUrl" placeholder="请输入监听地址"> </a-input>
        <a-select v-model:value="model.serviceType" size="middle">
          <a-select-option value="IIS">IIS 网站</a-select-option>
          <a-select-option value="Console">终端程序</a-select-option>
          <a-select-option value="Service">Windows服务</a-select-option>
          <a-select-option value="Systemd">Linux Systemd服务</a-select-option>
          <a-select-option value="Dir">静态目录</a-select-option>
        </a-select>
      </a-flex>
      <a-flex vertical gap="middle">
        <a-flex horizontal>
          <span>上次部署:</span><span>{{ format(model.lastDeployTime) }}</span>
        </a-flex>
        <a-flex horizontal>
          <span>加入时间:</span><span>{{ format(model.inDate) }}</span>
        </a-flex>
        <a-flex horizontal>
          <span>修改时间:</span><span>{{ format(model.editDate) }}</span>
        </a-flex>
        <a-button @click="selServerPath">选择服务器路径</a-button>
        <a-button @click="selServerIIS">选择IIS服务</a-button>
      </a-flex>
    </a-flex>
  </a-modal>

  <a-modal v-model:open="deployModalOpen" :title="modelDeploy.deployTitle">
    <a-flex vertical gap="middle">
      <a-flex horizontal gap="middle">
        <a-select v-model:value="modelDeploy.deployType" size="middle" style="min-width: 150px;">
          <a-select-option value="files">文件选择</a-select-option>
          <a-select-option value="dir">目录</a-select-option>
          <a-select-option value="zip">压缩包</a-select-option>
        </a-select>
        <input type="file" id="dir-selector" hidden @change="selectA" webkitdirectory directory multiple />
        <input type="file" id="file-selector" hidden @change="selectA" webkitfile />
        <input type="file" id="multifile-selector" hidden @change="selectA" webkitfile multiple />
      </a-flex>
      <a-textarea v-model:value="modelDeploy.paths"></a-textarea>
      <a-button @click="deploy">部署</a-button>
    </a-flex>
  
  </a-modal>

 
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'
import { notification, message } from 'ant-design-vue'
import type { TreeProps } from 'ant-design-vue'
import { ofetch } from 'ofetch'
import dayjs from 'dayjs'
import {
  DeploymentUnitOutlined,
  RetweetOutlined,
  CloseCircleOutlined,
  FolderViewOutlined,
  MenuUnfoldOutlined,
  UserOutlined,
  UserSwitchOutlined
} from '@ant-design/icons-vue'
import JSZip from 'jszip'
import {SparkMD5} from 'spark-md5';

const zip = new JSZip();
const data = ref([])
const apiFetch = ofetch.create({ baseURL: 'http://124.223.93.57:5000' })
const router = useRouter()
const treeData = ref<TreeProps['treeData']>([])
const viewFolderOpen = ref(false)
const curPath = ref('')

const serviceModalOpen = ref(false)
const tt = ref('修改服务')
const model = ref({})
const isCanSelect = ref(false)
const selectedPath = ref('未选择')
const selectedIIS = ref({})
const iisList = ref([])
const viewIISListOpen = ref(false)
const deployModalOpen = ref(false)
const modelDeploy = ref({
  deployType:'files',
  paths:'9999',
  deployTitle:'部署服务-',
  model:{}
})


async function selectA(e) {
  console.log(e)
  const files:FileList = e.target.files
  if (files.length >=1) {
    //modelDeploy.value.paths = files[0] + files[0].name
    for (const file of files) {
      const fileContent = await file.text();
      zip.file(file.name, fileContent);
    }

    zip.generateAsync({type:"blob"})
      .then((content)=> {
        doDeploy(content)
      });



  }

  
}

async function doDeploy(content) {
  const formData = new FormData();
  let h = SparkMD5.hash(content)
  formData.append("file", content);
  formData.append("hash", h);
  formData.append("size", content.length);
  formData.append("serviceId", modelDeploy.value.model.id);
   apiFetch('/api/Deploy/Deploy',{
    method: 'POST',
    body: formData,
    headers: {
        'x-token': localStorage.token
      }
   }).then(resp=>{
    console.log(resp)
   })
}

function deploy() {
  console.log('doOpenSelect',modelDeploy.value)
  if (modelDeploy.value.deployType=='files') {
     document.getElementById('multifile-selector')?.click();
  } else if (modelDeploy.value.deployType == 'dir') {
    document.getElementById('dir-selector')?.click();
  } else if (modelDeploy.value.deployType=='zip') {
    document.getElementById('file-selector')?.setAttribute('accept','.zip')
    document.getElementById('file-selector')?.click();
  }
}


//{selected: bool, selectedNodes, node, event}
function treeSelect(selectedKeys: any, e: { node: { isLeaf: any; key: string }; selected: boolean }) {
  if (!e.node.isLeaf) {
    selectedPath.value = e.node.key
  } else {
    e.selected = false
  }
}

function format(inParam: string | number | Date | dayjs.Dayjs | null | undefined) {
  return dayjs(inParam).format('YYYY-MM-DD HH:mm:ss')
}

function showEditOrAdd(isEdit: boolean, model1: any = undefined) {
  if (isEdit) {
    tt.value = '修改服务'
    model.value = model1
  } else {
    tt.value = '添加服务'
    model.value = {
      name: '',
      serviceName: '',
      arg: '',
      realPath: '',
      listenUrl: '',
      serviceType: '',
      lastDeployTime: '',
      inDate: '',
      editDate: ''
    }
  }
  serviceModalOpen.value = true
}

const onLoadData: TreeProps['loadData'] = (treeNode) => {
  return new Promise<void>((resolve) => {
    if (treeNode.isLeaf) {
      resolve()
      return
    }
    apiFetch('/api/Service/DirTree', {
      method: 'GET',
      query: {
        path: treeNode.key
      },
      headers: {
        'x-token': localStorage.token
      }
    }).then((resp) => {
      //插入子目录到对应的位置
      let a = resp.data.map((r) => {
        return {
          title: r.text,
          key: r.fullPath,
          pathType: r.pathType,
          isLeaf: r.pathType == 'File'
        }
      })
      treeNode.dataRef.children = a
      treeData.value = [...treeData.value]
      resolve()
    })
  })
}

const showError = (message: string) => {
  notification.open({
    message: '错误',
    description: message,
    duration: 2
  })
}
const showInfo = (message: string) => {
  notification.open({
    message: '信息',
    description: message,
    duration: 2
  })
}

function editService(item: any) {
  console.log('editService', JSON.stringify(item))
  showEditOrAdd(true, item)
  refreshData()
}
function refreshStatus() {
  data.value.forEach((item,_) =>{
      apiFetch('/api/Service/ServiceStatus',{
        headers: {
        'x-token': localStorage.token
       },
        query: {serviceId: item.id}
      }).then((resp)=>{
        //color: green;
        if (resp.data.status=='Running') {
          item.color = 'color: green;'
          item.status = '运行中'
        } else if (resp.data.status=='Stoped') {
          item.color = 'color: red;'
          item.status = '已停止'
        } else {
          item.color = 'color: black;'
          item.status = '未知'
        }
      })

    })
}

onMounted(() => {
  refreshData()
  // setInterval(()=>{
  //   refreshStatus()
  // },15000)
  
})
function refreshData() {
  apiFetch('/api/Service/GetByServer', {
      headers: {
        'x-token': localStorage.token
      },
      query: { serverId: '' }
    }).then((resp) => {
      data.value = resp.data
      //console.log(data.value)
      //refreshStatus()
    })
}

function switchUserClick() {
  localStorage.token = undefined
  router.push('/')
}
function userManageClick() {
  router.push('/users')
}
function deploymentClick(item: any) {
  console.log(item)
  //showInfo(`部署被点击:${JSON.stringify(item)}`)
  modelDeploy.value.deployTitle = `部署服务- ${item.name} ${item.serviceName}`
  modelDeploy.value.model = item
  deployModalOpen.value = true
}

function selectFolder() {
  
}


function confirmReboot(serviceId: any) {
  apiFetch('/api/Service/ServiceAction', {
    method: 'POST',
    query: {
      serviceId: serviceId,
      actionType: 'ActionReboot'
    },
    headers: {
      'x-token': localStorage.token
    }
  }).then((resp) => {
    if (resp.code == 200) {
      message.success('重启成功')
    }
  })
}
function confirmClose(serviceId: any) {
  apiFetch('/api/Service/ServiceAction', {
    method: 'POST',
    query: {
      serviceId: serviceId,
      actionType: 'ActionStop'
    },
    headers: {
      'x-token': localStorage.token
    }
  }).then((resp) => {
    if (resp.code == 200) {
      message.success('关闭成功')
    }
  })
}

function selServerPath() {
  viewFolder('C:\\', true)
}
function selPath() {
  model.value.realPath = selectedPath.value
  viewFolderOpen.value = false
}
function selServerIIS() {
  viewIIS()
}
function selIIS() {
  //将IIS信息填写到当前model
  model.value.name = selectedIIS.value.name
  model.value.serviceName = selectedIIS.value.serviceName
  model.value.arg = selectedIIS.value.arg
  model.value.realPath = selectedIIS.value.realPath
  model.value.listenUrl = selectedIIS.value.listenUrl
  model.value.serviceType = 'IIS'
  model.value.serverId = selectedIIS.value.serverId
  console.log(model.value)
  viewIISListOpen.value = false
}

function viewFolder(path: string, isSel: boolean = false) {
  isCanSelect.value = !isSel
  apiFetch('/api/Service/DirTree', {
    method: 'GET',
    query: {
      path: path
    },
    headers: {
      'x-token': localStorage.token
    }
  }).then((resp) => {
    curPath.value = path
    treeData.value = resp.data.map((r: { text: any; fullPath: any; pathType: string }) => {
      return {
        title: r.text,
        key: r.fullPath,
        pathType: r.pathType,
        isLeaf: r.pathType == 'File'
      }
    })
    viewFolderOpen.value = true
  })
}
function viewIIS() {
  isCanSelect.value = false
  apiFetch('/api/Service/IISServiceList', {
    method: 'GET',
    headers: {
      'x-token': localStorage.token
    }
  }).then((resp) => {
    iisList.value = resp.data
    viewIISListOpen.value = true
  })
}
function iisListClick(item: {}) {
  selectedIIS.value = item
}
function confirmDelService(serviceId: any) {
  apiFetch('/api/Service/DeleteService', {
    method: 'POST',
    query: {
      serviceId: serviceId,
    },
    headers: {
      'x-token': localStorage.token
    }
  }).then((resp) => {
    if (resp.code == 200) {
      message.success('删除成功')
      refreshData()
    } else {
      showError(resp.message)
    }
  })
}
</script>
