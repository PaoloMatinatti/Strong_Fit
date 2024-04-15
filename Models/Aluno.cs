namespace Projeto_BackEnd.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string E_mail { get; set; }
        public string Instagram { get; set; }
        public string Telefone { get; set; }
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }

        public ICollection<Treino> Treinos { get; set; }

    }
}
