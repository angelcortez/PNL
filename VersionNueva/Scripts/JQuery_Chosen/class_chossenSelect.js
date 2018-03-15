

        $(function () {
            PageInit_AlertOrNotification();
        });

        function PageInit_AlertOrNotification() {


            $(".chosen-select").chosen({
                allow_single_deselect: true,
                no_results_text: "No existe: ",
                width: "95%",
                placeholder_text_multiple: "Selecciona el elemento a agregar",
                multiple: true
            });


        }
   
   