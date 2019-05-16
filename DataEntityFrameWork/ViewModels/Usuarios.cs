namespace DataEntityFrameWork.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UsuariosViewModels
    {
        public int UsuariosId { get; set; }
        public string UsuarioNomeCompleto { get; set; }
        public string Apelido { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public bool Estado { get; set; }
        public byte[] Perfil { get; set; }


        public int GrupoId { get; set; }
        public GruposViewModels Grupos { get; set; }
        public virtual List<LogsViewModels> Logs { get; set; }
    }
}
