<template>
    <a-page-header
        style="border: 0px solid rgb(235, 237, 240)"
        title="用户管理"
        sub-title="管理用户和审核"
        @back="() => router.push('/home')"
  >
</a-page-header>
  <a-flex vertical gap="middle">
    <a-flex horizontal gap="middle">
      <a-button type="primary" @click="newUserClick">新用户</a-button>
      <a-checkbox v-model:checked="onlyChecked" @change="onlyChange">仅显示未审核</a-checkbox>
    </a-flex>
    <a-table :dataSource="data" :columns="columns" style="width: 1800px">
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'isadmin'">
          <a-checkbox :checked="record.isAdmin" />
        </template>
        <template v-if="column.key === 'isenable'">
          <a-checkbox :checked="record.enable" />
        </template>
        <template v-if="column.key === 'indate'">
          <span>{{ format(record.inDate) }}</span>
        </template>
        <template v-if="column.key === 'editdate'">
          <span>{{ format(record.editDate) }}</span>
        </template>
        <template v-if="column.key === 'lastlogintime'">
          <span>{{ format(record.lastLoginTime) }}</span>
        </template>
        <template v-if="column.key === 'action'">
          <span>
            <a>修改</a>
            <a v-if="record.enable === true">停用</a>
            
            <a>删除</a>
            <a v-if="record.enable === false">审核</a>

          </span>
        </template>
      </template>
    </a-table>
    
  </a-flex>
</template>
<script setup lang="ts">
import { useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'
import { notification } from 'ant-design-vue'
import { ofetch } from 'ofetch'
import dayjs from 'dayjs'
const data = ref([])
const apiFetch = ofetch.create({ baseURL: 'http://124.223.93.57:5000' })
const router = useRouter()
const onlyChecked = ref(false)

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

const columns = [
  {
    title: '用户名',
    dataIndex: 'name',
    width: '10%'
  },
  {
    title: '邮箱',
    dataIndex: 'email',
    width: '10%'
  },
  {
    title: '管理员',
    dataIndex: 'isAdmin',
    width: '15%',
    key: 'isadmin'
  },
  {
    title: '启用',
    dataIndex: 'enable',
    width: '10%',
    key: 'isenable'
  },
  {
    title: '加入时间',
    dataIndex: 'inDate',
    width: '15%',
    key: 'indate'
  },
  {
    title: '修改时间',
    dataIndex: 'editDate',
    width: '15%',
    key: 'editdate'
  },
  {
    title: '上次登录',
    dataIndex: 'lastLoginTime',
    width: '15%',
    key: 'lastlogintime'
  },
  {
    title: '操作',
    width:'30%',
    key: 'action',
  },
]

onMounted(() => {
    getUsers()
})

function getUsers() {
    apiFetch('/api/User/GetUsers', {
    headers: {
      'x-token': localStorage.token
    },
    query: { isEnable: !onlyChecked.value }
  }).then((resp) => {
    data.value = resp.data
  })
}

function onlyChange() {
    getUsers()
}
function format(inParam) {
  return dayjs(inParam).format('YYYY-MM-DD HH:mm:ss')
}

function newUserClick() {

}
</script>

<style>

</style>