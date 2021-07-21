<template>
  <div class="container-fluid">
    <div class="row mt-5 ml-3">
      <div class="col-12">
        <form action="">
          <input type="text" placeholder="list name">
          <input type="button" value="add list">
        </form>
      </div>
      <div class="col-12 mt-3">
        <h1>{{ account.name }}'s Lists</h1>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
