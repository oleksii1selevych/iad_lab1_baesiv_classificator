import { checkErrors } from "./requestHelper";

export default class ClasificationService {
    constructor(){
        this.apiRoute = import.meta.env.VITE_API_HOST + '/api/classification';
    }

    async getAllClassifications(){
        try{
            
            let response = await fetch(this.apiRoute);
            
            checkErrors(response);

            let classifications = await response.json();
            return classifications;

        } catch(error) {
            console.log(error)
        }
    }
}