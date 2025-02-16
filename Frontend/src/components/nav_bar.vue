<script setup>
import logo from '@/assets/img/weather_logo.png'
</script>

<template>
  <nav class="flex justify-start">
    <img class="h-10 w-auto" v-bind:src="logo" />
    <a href="current_weather.vue">Current weather</a>
    <a href="./data_base_weather.vue">Weather data base</a>
  </nav>
  <hr />
  <br />
  <br />
</template>
