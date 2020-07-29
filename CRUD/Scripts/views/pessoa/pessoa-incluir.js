$(document).ready(function () {   

    $('#formCadastro').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "Nome": $(this).find("#Nome").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "CPF": $(this).find("#CPF").val(),
                "RG": $(this).find("#RG").val(),
                "Email": $(this).find("#Email").val(),
                "CEP": $(this).find("#CEP").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),   
                "Estado": $(this).find("#Estado").val(),
                "Telefone": $(this).find("#Telefone").val(),
                "Celular": $(this).find("#Celular").val()               
            },
            error:
                function (r) {
                    if (r.status == 400)
                        modalDialog("Ocorreu um erro!", r.responseJSON);
                    else if (r.status == 500)
                        modalDialog("Ocorreu um erro!", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    modalDialog("Sucesso!", r)
                    $("#formCadastro")[0].reset();
                }
        });
    })



    function modalDialog(titulo, texto) {
        var random = Math.random().toString().replace('.', '');
        var text = ' <div class="modal fade" id="' + random + '" tabindex="-1" role="dialog" aria-labelledby="modalMsg" aria-hidden="true">  ' +
            '      <div class="modal-dialog" role=" document">                                                                               ' +
            '         <div class="modal-content">                                                                                            ' + '                                                                                                           ' +
            '                 <div class=" modal-header" >                                                                                   ' +
            '                     <h5 class=" modal-title">' + titulo + '</h5>                                                               ' +
            '                         <button type="button" class="close" data-dismiss="modal" onclick="retorno()" aria-label="Close">       ' +
            '                            <span aria-hidden="true">&times;</span>                                                             ' +
            '                          </button>                                                                                             ' +
            '                   </div >                                                                                                      ' +
            '                  <div class="modal-body">                                                                                      ' +
            '                     <p>' + texto + '</p>                                                                                       ' +
            '                  </div>                                                                                                        ' +
            '                  <div class="modal-footer">                                                                                    ' +
            '                       <button type="button" class="btn btn-primary" onclick="retorno()" data-dismiss="modal">Fechar</button>   ' +
            '                  </div >                                                                                                       ' +
            '          </div>                                                                                                                ' +
            '      </div>                                                                                                                    ' +
            ' </div>                                                                                                                         ';


        $('body').append(text);
        $('#' + random).modal('show');
    }


})