$(document).ready(function () {

    $.ajax({
        url: '/Tarefas/ConstruirTabelaDeTarefas',
        success: function (result){
            $('#tableDiv').html(result);
        }
    });
});