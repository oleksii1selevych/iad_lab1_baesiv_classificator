<template>
  <ConfirmDialog/>
  <Toast position="top-right" />
  <form class="border-1 border-blue-200 border-solid border-round p-4">
    <h1 class="text-center text-blue-200 md-5">Baesov Classificator</h1>
    <div class="grid">
      <div class="col-8">
        <div class="field">
          <label for="message" 
                class="text-color text-base">
                Please, enter here your text message..
          </label>
          <TextArea :auto-resize="true" rows="6" id="message" v-model="inputMessage" class="w-full" />
        </div>
      </div>
      <div class="col-4">
        <div class="field">
          <label class="text-color text-base">Select Classification: </label>
          <ListBox
            :options="classifications"
            optionLabel="name"
            optionValue="id"
            v-model="classificationId"
          />
        </div>
      </div>
    </div>
    <div class="grid">
        <div class="col-3 col-offset-3">
            <Button @click="addTrainingMessage" class="w-full p-button-success" label="Add training message"/>
        </div>
        <div class="col-3">
            <Button @click="classifyMessage" class="w-full" label="Classify"/>
        </div>
    </div>
  </form>
</template>

<script>
import TextArea from "primevue/textarea";
import ListBox from "primevue/listbox";
import Button from "primevue/button";
import ConfirmDialog from 'primevue/confirmdialog';
import Toast from 'primevue/toast';

import MessageService from '../api-services/messageService.js';
import ResultService from "../api-services/resultService.js";
import ClassificationService from "../api-services/classificationService.js";

export default {
  components: { TextArea, ListBox, Button, ConfirmDialog, Toast },
  created(){
      this.messageService = new MessageService();
      this.resultService = new ResultService();
      this.classificationService = new ClassificationService();
  },
  async mounted(){
    this.classifications = await this.classificationService.getAllClassifications();
  },
  data() {
    return {
      inputMessage: "",
      classificationId: null,
      classifications: null
    };
  },methods:{
      async classifyMessage(){

         let messageDto = {
             classificationId:0,
             message:this.inputMessage
         }

        let result = await this.messageService.guessMessageClassification(messageDto);
        await this.makeResultConfirmation(result);

        this.setDefaults();
      },
      async makeResultConfirmation(messageDto){

        let classification = this.classifications.find(c => c.id == messageDto.classificationId);

        this.$confirm.require({
               message: `Is baesov classificator working correctly and it was a ${classification.name}?`,
                header: 'Confirm guess result',
                icon: 'pi pi-exclamation-triangle',
                accept: async () => {
                    await this.resultService.addResultAsync(true)
                    .then(addResult => this.createAddGuessResultToast(addResult));
                },
                reject: async () => {
                    await this.resultService.addResultAsync(false)
                    .then(addResult => this.createAddGuessResultToast(addResult));
                }
          })
      },

      async addTrainingMessage(){
          let messageDto = {
              message:this.inputMessage,
              classificationId:this.classificationId
          }

          let result = await this.messageService.addTrainingMessage(messageDto);
          this.setDefaults();
          this.createAddMessageToast(result);
      },

      createAddMessageToast(result){
        let details = result ? 'Training message was successfully added' :
          'Some errors happened while adding training message';
        this.showToast(result, details);
      },

      createAddGuessResultToast(result){
        let details = result ? 'Guess result was successfully added':
        'Some errors happened while adding guess result';
        this.showToast(result, details);
      },

      showToast(result, details){
          let normalSummary = 'Successfully added';
          let errorSummary = 'Error happened';

          let resultToast = {
              severity:result ? 'success' : 'error',
              summary: result ? normalSummary : errorSummary,
              detail: details,
              life:3000
          };

           this.$toast.add(resultToast);
      },
      setDefaults(){
          this.classificationId = null;
          this.inputMessage = null;
      }
  }
};
</script>

<style scoped></style>
