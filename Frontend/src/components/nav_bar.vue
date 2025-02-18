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
    <form class="relative ml-auto">
      <label for="search" class="sr-only">Search</label>
      <div class="relative">
        <div class="absolute inset-y-0 left-3 flex items-center pointer-events-none">
          <svg
            class="w-4 h-4 text-gray-400"
            aria-hidden="true"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 20 20"
          >
            <path
              stroke="currentColor"
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
            />
          </svg>
        </div>
        <input
          type="search"
          id="search"
          class="block w-90 p-3 pl-10 text-sm text-white border border-gray-600 rounded-lg bg-gray-800 focus:ring-blue-500 focus:border-blue-500 placeholder-gray-400"
          placeholder="Search"
          required
        />
        <button
          type="submit"
          class="absolute right-2 bottom-2 bg-grey-900 hover:bg-grey-300 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 text-white"
        >
          Search
        </button>
      </div>
    </form>
  </nav>
  <hr />
  <br />
  <br />
</template>
