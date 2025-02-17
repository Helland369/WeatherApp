<script setup>
import logo from '@/assets/img/weather_logo.png'

import { RouterLink } from 'vue-router'
</script>

<template>
  <nav class="flex justify-start">
    <img class="h-10 w-auto" v-bind:src="logo" />
    <RouterLink to="/">Current weather</RouterLink>
    <RouterLink to="/data_base">Weather data base</RouterLink>
  </nav>
  <hr />
  <br />
  <br />
</template>
