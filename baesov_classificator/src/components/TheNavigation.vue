<template>
    <TabMenu :model="items" class="mt-0"/>
</template>

<script>
import TabMenu from 'primevue/tabmenu';

export default {
    components:{ TabMenu },
    data(){
        return {
            items:[
                { label: 'Classificator', to: '/classificator'},
                { label :'Graph', to:'/graph' }
            ]
        }
    }
}

</script>

<style scoped>

</style>