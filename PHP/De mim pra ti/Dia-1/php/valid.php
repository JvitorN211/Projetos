<?php

session_start();

$password   = $_POST['pw'];

if (empty($password)) {
    echo "Insira a chave!";
    return;
}

if ($password == "EU" || $password == "Eu" || $password == "eu" || $password == "eU") {
    echo '<!DOCTYPE html>
    <html lang="pt-br">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <link rel="stylesheet" href="../css/styles-result.css">
            <link rel="icon" href="../img/pts.ico" type="image/x-icon">
            <title>:...12/06/2022...:</title>
        </head>
        <body>
            <div class="container">
                <h2>PARABÉNS</h2>
                <h3>Você descobriu o desfecho do primeiro capítulo desta linda história</h3>
                <div class="texto">
                    <p>O ser mais importante do universo, parou então para ouvir o pedido daquele garotinho, e vendo que havia sinceridade em seu coração atendeu ao seu pedido, mas o pequeno menino só iria descobrir isso alguns anos depois.</p>
                    <p>Você foi a resposta da minha mais sincera oração, Deus te criou com todo amor e carinho para que pudessemos compartilhar desse amor um para o outro. Eu não entendia nada sobre esse sentimento até conhece-lo manifestado em alguém de carne e osso.</p>
                    <p>Não o entendia até conhecer</p>
                    <h1>VOCÊ!</h1>
                    <h4>Eu te amo!</h4>
                    <p>De mim pra ti</p>
                </div>
            </div>
        </body>
    </html>';
}else if ($password == "Jessica" || $password == "Jessica Emanuely" || $password == "Jessica Emanuely dos Santos Silva") {
    $_SESSION['mensagem-quente'] = "Quase isso, mas... Quem é " . $password . " ?";
    header ('location: historia1.php');
    return;
}else {
    $_SESSION['mensagem-de-erro'] = "Hm... " . $password . " não é o que o campo espera receber, deveria tentar outra resposta.";
    header ('location: historia1.php');
    return;
}