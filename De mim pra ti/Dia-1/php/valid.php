<?php

$password   = $_POST['pw'];

if ($password == "EU" || $password == "Eu" || $password == "eu" || $password == "eU") {
    echo "O nadador " . $nome . " compete na categoria " . $categorias[$i];
}else {
    var_dump($password);
}