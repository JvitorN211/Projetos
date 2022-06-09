<?php
    session_start();
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../css/styles-historia1.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v6.1.1/css/all.css" integrity="sha384-/frq1SRXYH/bSyou/HUp/hib7RVN1TawQYja658FEOodR/FQBKVqT9Ol+Oz3Olq5" crossorigin="anonymous">
    <link rel="icon" href="../img/p1.ico" type="image/x-icon">
    <title>:...12/06/2022...:</title>
</head>
<body>
    <div class="container">
        <div>
            <h1>A parte que faltava</h1>
        </div>
        <div class="texto">
            <p>Em um planeta remoto, localizado na Via Lactea, sendo em sua maioria composto por água, habitado por uma infinidade de criaturas, aliás, o único planeta que apresenta condições de vida entre os constituintes do Sistema Solar, um planeta chamado Terra. Possuindo um total de 510.100.000 km², tendo aproximadamente 7,753 bilhões de seres humanos (criatura dominante deste planeta). Qualquer humano que vive neste ambiente, uma hora ou outra precisa entender que não se pode viver só, e é assim que nossa história começa.</p>
            <p>Um pequeno grão de areia em meio ao mais vasto universo, este é o tamanho daquela criança. Ela não estava feliz, sentia que estava incompleta, sensação esta que assola a humanidade a milênios. Alguns destes seres procuram preencher esta lacuna com as mais diversas coisas, alguns buscam esta parte faltosa em objetos, outros em momentos, e assim, cada um trilha sua história, em busca daquilo que pode completa-lo, que pode lhe trazer o sentimento de felicidade plena.</p>
            <p>Se estiver pensando que este era o caso daquela criança... não, ele era muito jovem ainda pra entender a vida como um todo e ainda sim fez sua aposta, marcou uma auditoria com o criador do universo, esta divindade que cuida de toda a vida existente, os seres humanos o chamam de Deus. Aquela criança então o chamou através de um ato solene chamado de oração; Deus o ouviu; ele então começou a se explicar, contando-lhe que que sentia um vazio dentro de si, algo que ele não sabia o que era, mas que lhe fazia muita falta...</p>
                <?php
                    $mensagemQuente = isset($_SESSION['mensagem-quente']) ? $_SESSION['mensagem-quente'] : '';
                    if(!empty($mensagemQuente)) {
                        echo $mensagemQuente;
                        session_destroy();
                    }
                    $mensagemDeErro = isset($_SESSION['mensagem-de-erro']) ? $_SESSION['mensagem-de-erro'] : '';
                    if(!empty($mensagemDeErro)) {
                        echo $mensagemDeErro;
                        session_destroy();
                    }
                ?>
            <div id="arrow">
                <i style="display: block;" onclick="displayKey()" id="animation" class="fa-solid fa-arrow-down"></i>
            </div>
            <div style="display: none;" id="key">
                <form action="valid.php" method="post">
                    
                    <a id="code-key">28</a>
                    <label for="inputPassword5" class="form-label">C rctvg swg hcnvcxc</label>
                    <input name="pw" type="password" id="inputPassword5" class="form-control" aria-describedby="passwordHelpBlock">
                    <a id="help" href="../../index.html">Olhe mais a fundo</a>
                </form>
            </div>
        </div>
    </div>
    <script>
        function displayKey() {
            var arrow = document.getElementById('animation');
            arrow.classList.toggle('disactive');

            var discover = document.getElementById('key');
            discover.classList.toggle('active')
        }
    </script>
</body>
</html>