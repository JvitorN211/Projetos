﻿using Agenda___IATEC.Enums;
using System.ComponentModel.DataAnnotations;

namespace Agenda___IATEC.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o tipo de perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
