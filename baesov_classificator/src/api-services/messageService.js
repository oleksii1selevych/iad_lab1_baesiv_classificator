import { checkErrors } from "./requestHelper";

export default class MessageService {
    constructor(){
        this.apiRoute = import.meta.env.VITE_API_HOST + '/api/message';
    }

    async addTrainingMessage(messageDto){
        try{
            let response = await fetch(this.apiRoute + '/training', {
                method:'POST',
                headers: {
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(messageDto)
            })

            checkErrors(response);

            return true;

        } catch(error){
            console.log(error);
            return false;
        }
    }

    async guessMessageClassification(messageDto){
        try{
            let response = await fetch(this.apiRoute + '/guess', {
                method:'POST',
                headers: {
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(messageDto)
            })
            
            checkErrors(response);
            
            return await response.json();

        } catch(error){
            console.log(error);
            return false;
        }
    }
}