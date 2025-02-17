<script setup>
import logo from '@/assets/img/weather_logo.png'

import { RouterLink } from 'vue-router'
</script>

<template>
  <nav class="flex items-center gap-6 bg-gray-900 text-white p-4">
    <img class="h-16 w-auto" v-bind:src="logo" />
    <RouterLink class="text-lg font-medium hover:underline" to="/">Current weather</RouterLink>
    <RouterLink class="text-lg font-medium hover:underline" to="/data_base"
      >Weather data base</RouterLink
    >
  </nav>
  <hr />
  <br />
  <br />
</template>
