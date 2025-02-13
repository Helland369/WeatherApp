<script>
import axios from 'axios'

export default {
  data() {
    return {
      weatherData: [],
    }
  },
  methods: {
    async fetchApi() {
      try {
        const response = await axios.get('http://localhost:5145/api')
        this.weatherData = response.data
      } catch (err) {
        console.log('Failed to fetch data', err)
      }
    },
  },
  mounted() {
    this.fetchApi()
  },
}
</script>

<template></template>

<style></style>
