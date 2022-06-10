const helpers = {
    checkErrors(response){
        if(!response.ok){
            let error = `Some error happened while executing the request. Code --> ${response.status}`;
            throw new Error(error);
        }
    }
}   


export const checkErrors = helpers.checkErrors;
