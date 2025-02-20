<script setup>
import logo from '@/assets/img/weather_logo.png'
import { RouterLink, useRouter } from 'vue-router'
import { ref } from 'vue'

const router = useRouter()
const city = ref('')

const searchCity = () => {
  if (city.value.trim() === '') return
  router.push(`/weather/${city.value}`)
}
</script>

<template>
  <nav class="flex items-center gap-6 bg-gray-900 text-white p-4">
    <img class="h-16 w-auto" v-bind:src="logo" />
    <RouterLink class="text-lg font-medium hover:underline" to="/">Current weather</RouterLink>
    <RouterLink class="text-lg font-medium hover:underline" to="/data_base"
      >Weather data base</RouterLink
    >
    <form class="relative ml-auto" @submit.prevent="searchCity">
      <input v-model="city" type="search" placeholder="City" />
      <button type="submit">Search</button>
    </form>
  </nav>
  <hr />
  <br />
  <br />
</template>
