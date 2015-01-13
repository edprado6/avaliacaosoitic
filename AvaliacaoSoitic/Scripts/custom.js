$(document).on("click", "#btn-delete-categoria", function (event) {
    event.preventDefault();
    var categoria_id = $(this).data('id');
    $('#excluir-action').data('categoria_id', categoria_id);
    $('#myModal').modal('show');
});


$(document).ready(function () {

    /* Chama o método que irá excluir uma categoria. */
    $('#excluir-action').click(function (event) {
        var categoria_id = $(this).data('categoria_id');        
        document.location = '../Categoria/Delete/' + categoria_id;
        //window.location.href = '../Categoria/Delete/' + categoria_id;
    });

    $('#dataTables-categoria').DataTable({
        responsive: true
    });

});