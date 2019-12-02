/**
 * script responsavel por Validar os dados do Torneio e enviar para o backend
*/

document.addEventListener("DOMContentLoaded", function () {

});


document.getElementById('btnTournamentRun').addEventListener('click', function () {
    TournamentStart();
});

document.getElementById('btnAdd').addEventListener('click', function () {
    AddGame();
});

function AddGame() {
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
        erro += "Para uma disputa, É necessário informar os 2 jogadores<br/>";
    }

    //Verifica se os movimentos são válidos
    if ((actionp1 != "R" && actionp1 != "P" && actionp1 != "S") || (actionp2 != "R" && actionp2 != "P" && actionp2 != "S")) {
        erro += "O movimento de ambos os jogadores deve ser selecionado<br/>";
    }

    if (erro != null && erro != "") {
        toastr['error'](erro, "ERRO");
    }
    else {
        let tr = `<tr>
                    <td>${namep1}</td>
                    <td>${actionp1}</td>
                    <td>VS</td>
                    <td >${namep2}</td>
                    <td >${actionp2}</td>
                </tr>`;

        jQuery('#tblGame > tbody').append(tr);

        document.getElementById("txtnamep1").value = "";
        document.getElementById("txtnamep2").value = "";
    }
}


function TournamentStart() {
    let namep1;
    let actionp1;
    let namep2;
    let actionp2;
    const Players = [];
    jQuery('#tblGame tbody > tr').each(function () {

        namep1 = jQuery(this).find('td').eq(0).text();
        actionp1 = jQuery(this).find('td').eq(1).text();

        namep2 = jQuery(this).find('td').eq(3).text();
        actionp2 = jQuery(this).find('td').eq(4).text();
        
        


        const Player1 = {
            Name: namep1,
            Action: actionp1
        };

        const Player2 = {
            Name: namep2,
            Action: actionp2
        };

        Players.push(Player1);
        Players.push(Player2);



    });


    fetch('run', {
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
                WinnerMsg += res.Action == "P" ? "PAPER" : res.Action == "R" ? "ROCK" : "SCISSOR";
                toastr['success'](WinnerMsg, "WINNER");

            }
            else
                toastr['error']("AÇÃO INVÁLIDA", 'ERRO');
        });
}