using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntNotaAclaratoria
{

    public int Id { get; set; }
    public int NacConsecutivo { get; set; }
    public DateTime NacFecha { get; set; }
    public int? IdPuc { get; set; }
    public int IdNotaaclaratoriatipo { get; set; }
    public string NacTitulo { get; set; }
    public string NacDetalle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }
    public string Estado {get; set;} 
  
    public CntNotaAclaratoriaTipo NotaAclaratoriaTipo { get; set; }
    public CntPuc CntPuct { get; set; }
    /* public ICollection<CntNotaAclaratoriaCuenta> notaAclaratoriaNotaAclaratoriaCuentas { get; set; } */
}