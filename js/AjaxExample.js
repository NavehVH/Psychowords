
function Ajax() {

    try {
        PageMethods.MethodName(parameter1, parameter2, onSucess, onError);
        function onSucess(result) {
            alert("Done... ");
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}