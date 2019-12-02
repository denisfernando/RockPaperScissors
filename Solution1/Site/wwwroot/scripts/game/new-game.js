/**
 * script responsavel por Validar os dados do Jogo e enviar para o backend
*/

document.addEventListener("DOMContentLoaded", function () {

});

document.getElementById('btnBattle').addEventListener('click', function () {
    Battle();
});




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
        
        const Players = [];
        Players.push(Player1);
        Players.push(Player2);


        fetch('play', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(Players)
        }).then(res => res.json())
            .then(res => {

                if (res != null) {

                    let WinnerMsg = res.Name + "<br/>";
                    WinnerMsg+=  res.Action == "P" ? "PAPER" : res.Action == "R" ? "ROCK" : "SCISSOR";
                    toastr['success'](WinnerMsg, "WINNER");

                }
                else
                    toastr['error']("AÇÃO INVÁLIDA", 'ERRO');
            });
    }
}

function desabilitarTudo() {
    $('#dvpadrao *').prop('disabled', true);
    document.getElementById('btnVoltar').disabled = false;

}