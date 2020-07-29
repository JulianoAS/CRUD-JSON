var success = false;

    function deletar(id) {             
            $.ajax({
                url: urlDeletar,
                method: "POST",
                data: {
                    "id": id
                },
                error:
                    function (r) {
                        if (r.status == 400)
                            modalDialog("Ocorreu um erro!", r.responseJSON);
                        else if (r.status == 500)
                            ModalDialog("Ocorreu um erro!", "Ocorreu um erro interno no servidor.");
                    },
                success:                    
                    function (r) {                    
                        modalDialog("Sucesso!", r)
                        success = true;
                    }      
            })
    }


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

function retorno() {
    if(success)location = location.href;
}