namespace DataEntityFrameWork.ViewModels
{
    using DataEntityFrameWork.Models;
    using System.ComponentModel.DataAnnotations;

    public class PermissoesViewModels
    {
        public int PermissoesId { get; set; }
        public bool Adicionar { get; set; }
        public bool Guardar { get; set; }
        public bool Atualizar { get; set; }
        public bool Apagar { get; set; }
        public bool Descontos { get; set; }
        public bool Dividas { get; set; }
        public bool Relatorios { get; set; }
        public bool Consultas { get; set; }
        public bool Promocoes { get; set; }
        public bool Definicoes { get; set; }
        public bool Backup { get; set; }
        public bool BackupManual { get; set; }
        public bool BackupAutomatico { get; set; }
        public bool BackupActivarDesativar { get; set; }
        public bool Graficos { get; set; }
        public bool Grupos { get; set; }
        public bool GruposAdicionar { get; set; }
        public bool GruposConsultar { get; set; }
        public bool Usuarios { get; set; }
        public bool UsuariosAdicionar { get; set; }
        public bool UsuariosConsultar { get; set; }
        public bool UsuariosHistorico { get; set; }
        public bool ErrosLogs { get; set; }
        public bool ErrosLogsReport { get; set; }
        public bool ModuloGeral { get; set; }

        public bool Alunos { get; set; }
        public bool Periodos { get; set; }
        public bool Turma { get; set; }
        public bool Classe { get; set; }
        public bool Disciplinas { get; set; }
        public bool Cursos { get; set; }

        public int GrupoId { get; set; }
        public Grupos Grupo { get; set; }
    }
}
