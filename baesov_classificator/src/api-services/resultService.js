import { checkErrors } from "./requestHelper";

export default class ResultService {
    constructor(){
        this.apiRoute = import.meta.env.VITE_API_HOST + '/api/result';
    }

    async getCorrectResultPercentagesAsync(){
        try {
            let response = await fetch(this.apiRoute);
            
            checkErrors(response);

            let results = await response.json();
            return results;

        } catch(error) {
            console.log(error);
        }
    }

    async addResultAsync(result){
        try {
            let response = await fetch(this.apiRoute, {
                method:'POST',
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(result)
            });

            checkErrors(response);

            return true;

        } catch(error){
            console.log(error);
        }
    }
}