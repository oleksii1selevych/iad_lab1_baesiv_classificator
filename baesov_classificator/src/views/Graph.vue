<template>
       <Chart type="line" :data="classificationData"/>
</template>


<script>
import Chart from 'primevue/chart';
import ResultService from '../api-services/resultService'

export default {
    components:{ Chart },
    created(){
        this.resultService = new ResultService();
    },
    async mounted(){
        let results = await this.resultService.getCorrectResultPercentagesAsync();
        let labels = [];
        let data = [];
        results.forEach(r => {
            data.push(r.percentage);
            labels.push(r.quantity.toString());
        });
        this.classificationData = {
            labels:labels,
            datasets:[
                {
                    label:'Correct classification percentages',
                    data,
                    color:'#42A5F5'
                }
            ]
        }
        // По факту мне нужны только border-color и background color
    },
    data(){
        return {
            classificationData:{}
        }
    }
}
</script>

<style scoped>

</style>