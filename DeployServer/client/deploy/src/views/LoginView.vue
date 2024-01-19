<script setup lang="ts">
import { UserOutlined, LockOutlined, InfoCircleOutlined, MailOutlined } from '@ant-design/icons-vue'
import { notification } from 'ant-design-vue'
import { useRouter } from 'vue-router'
import {ref} from 'vue'
import { ofetch } from 'ofetch'

const apiFetch = ofetch.create({ baseURL: 'http://124.223.93.57:5000' })


const userName = ref('admin')
const password = ref('admin')
const remember = ref(true)
const regopen = ref(false)
const regUserName = ref('')
const regEmail = ref('')
const regPass = ref('')
const regTwicePass = ref('')
const curlocation = ref(window.location.origin)



const showError = (message: string) => {
  notification.error({
    message: 'error',
    description: message,
    
  })
}

const router = useRouter()



//登录
async function login() {
  console.log(userName.value, password.value)
  await apiFetch('/api/User/Login', {
    method: 'POST',
    query: { username: userName.value, password: password.value },
    async onResponseError({ request, response, options }) {
    // Log error
    showError(response.statusText)
  },
  }).then((resp) => {
    console.log(resp.data.token)
    if (resp.code==200) {
      localStorage.token = resp.data.token
      router.push('/home')
    } 
  })
}

function register() {
  regopen.value = true
}
function handleReg() {
  if (regPass.value != regTwicePass.value) {
    showError('两次密码不一致')
    return
  }
  apiFetch('/api/User/Register', {
    method: 'POST',
    query: { name: regUserName.value, email: regEmail.value, password: regPass.value },
    async onResponseError({ request, response, options }) {
    // Log error
    showError(response.statusText)
  },
  }).then((resp) => {
    if (resp.code === 200) {
      regopen.value = false
    } else {
      showError(resp.message)
    }
  })
}


</script>

<template>
  <div>
    <a-card title="欢迎使用部署工具" style="background: #ececec;width: 400px;">
      <a-flex gap="middle" vertical>
        <a-input v-model:value="userName" placeholder="请输入用户名">
          <template #prefix>
            <user-outlined />
          </template>
          <template #suffix>
            <a-tooltip title="登录名或邮箱地址">
              <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
            </a-tooltip>
          </template>
        </a-input>
        <a-input-password v-model:value="password" placeholder="请输入密码">
          <template #prefix>
            <lock-outlined />
          </template>
        </a-input-password>
        <a-checkbox :checked="remember">记住密码</a-checkbox>
        <a-button @click="login">登录</a-button>
        <a-button @click="register">注册</a-button>
        <a-divider />
        <a-flex gap="small" horizontal>
          <a-tag>v0.0.1</a-tag>
          <a-tag>Linx</a-tag>
          
          <a-tag>ant-design-vue</a-tag>
        </a-flex>
        <a-flex><a-tag>{{ curlocation }}</a-tag></a-flex>
      </a-flex>
    </a-card>
  </div>

  <a-modal v-model:open="regopen" title="注册" okText="注册" cancelText="取消" @ok="handleReg">
    <a-flex gap="middle" vertical>
      <a-input v-model:value="regUserName" placeholder="请输入用户名">
        <template #prefix>
          <user-outlined />
        </template>
        <template #suffix>
          <a-tooltip title="用户名">
            <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
          </a-tooltip>
        </template>
      </a-input>
      <a-input v-model:value="regEmail" placeholder="请输入邮箱地址">
        <template #prefix>
          <mail-outlined />
        </template>
        <template #suffix>
          <a-tooltip title="邮箱">
            <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
          </a-tooltip>
        </template>
      </a-input>
      <a-input-password v-model:value="regPass" placeholder="请输入密码">
        <template #prefix>
          <lock-outlined />
        </template>
      </a-input-password>
      <a-input-password v-model:value="regTwicePass" placeholder="请再次输入密码">
        <template #prefix>
          <lock-outlined />
        </template>
      </a-input-password>
    </a-flex>
  </a-modal>
</template>
