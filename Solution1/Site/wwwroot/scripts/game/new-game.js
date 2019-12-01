/**
 * script responsavel por Validar os dados do Jogo e enviar para o backend
*/

document.addEventListener("DOMContentLoaded", function () {

});

document.getElementById('btnBattle').addEventListener('click', function () {
    Battle();
});


////Definindo 
//document.getElementById('rrockp1').addEventListener('click', function () {
//    document.getElementById('actionp1').value = 'R';
//});

//document.getElementById('rpaperp1').addEventListener('click', function () {
//    document.getElementById('actionp1').value = 'P';
//});

//document.getElementById('rscissorsp1').addEventListener('click', function () {
//    document.getElementById('actionp1').value = 'S';
//});

//document.getElementById('rrockp2').addEventListener('click', function () {
//    document.getElementById('actionp2').value = 'R';
//});

//document.getElementById('rpaperp2').addEventListener('click', function () {
//    document.getElementById('actionp2').value = 'P';
//});

//document.getElementById('rscissorsp2').addEventListener('click', function () {
//    document.getElementById('actionp2').value = 'S';
//});





function Battle() {

    let namep1 = document.getElementById('txtnamep1').value;
    let rrockp1 = document.getElementById('rrockp1');
    let rpaperp1 = document.getElementById('rpaperp1');
    let rscissorsp1 = document.getElementById('rscissorsp1');
  

    let namep2 = document.getElementById('txtnamep2').value;
    let rrockp2 = document.getElementById('rrockp2');
    let rpaperp2 = document.getElementById('rpaperp2');
    let rscissorsp2 = document.getElementById('rscissorsp2');

    let actionp1 = rrockp1.checked ? "R" : rpaperp1.checked ? "P" : rscissorsp1.checked ? "S" : "";
    let actionp2 = rrockp2.checked ? "R" : rpaperp2.checked ? "P" : rscissorsp2.checked ? "S" : "";

    toastr['success']("Player 1: " + namep1 + "<br/>Action: " + actionp1);
    toastr['success']("Player 2: " + namep2 + "<br/>Action: " + actionp2);

    let erro = "";

    //Verifica se os 2 jogadores foram informados
    if (namep1 == null || namep2 == "" || namep2 == null || namep2 == "") {
        let wrong = valorDaDiv = $("#WrongNumberOfPlayersError").text();

        wrong = parseInt(wrong) + 1;

        document.getElementById("WrongNumberOfPlayersError").innerHTML = wrong;

        erro += "Para uma disputa, É necessário informar os 2 jogadores<br/>";
    }

    //Verifica se os movimentos são válidos
    if ((actionp1 != "R" && actionp1 != "P" && actionp1 != "S") ||( actionp2 != "R" && actionp2 != "P" && actionp2 != "S" ) ) {
        let wrong = valorDaDiv = $("#NoSuchStrategyError").text();

        wrong = parseInt(wrong) + 1;

        document.getElementById("NoSuchStrategyError").innerHTML = wrong;

        erro += "O movimento de ambos os jogadores deve ser selecionado<br/>";
    }
    if (erro != null && erro != "") {
        toastr['error'](erro);
    } else {

        let Player1 = {
            Name: namep1,
            Action: actionp1
        };

        let Player2 = {
            Name: namep2,
            Action: actionp2
        };
        
        const game = {
            Player1: Player1,
            Player2: Player2
        };

        fetch('battle', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(game)
        }).then(res => res.json())
            .then(res => {

                if (res == -1) {
                    toastr['error']("Esta descrição já foi cadastrada!", TITULO_TOASTR_ATENCAO);
                    document.getElementById('btnSalvarMotivoCancelamento').disabled = false;
                }
                else if (res >= 1) {
                    toastr['success'](MSG_SUCESSO, TITULO_TOASTR_SUCESSO);
                    desabilitarTudo();

                } else {
                    toastr['error'](MSG_ERRO_INSERIR, TITULO_TOASTR_ATENCAO);
                    document.getElementById('btnSalvarMotivoCancelamento').disabled = false;
                }

            });
    }
}

function desabilitarTudo() {
    $('#dvpadrao *').prop('disabled', true);
    document.getElementById('btnVoltar').disabled = false;

}