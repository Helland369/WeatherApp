<script setup>
import { GoogleMap, Marker } from 'vue3-google-map'

const center = { lat: 62.0, lng: 10.0 }
</script>

<template>
  <GoogleMap api-key="//APIKEY" style="width: 100%; height: 500px" :center="center" :zoom="6">
    <Marker :options="{ position: center }" />
  </GoogleMap>
</template>
