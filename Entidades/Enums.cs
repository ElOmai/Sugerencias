using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum TipoAlerta
    {
        SuccessAlert,
        ErrorAlert,
        ErrorAlertUser,
        ErrorAlertClave
    }
    public enum IconType
    {
        success,
        error,
        warning,
        info,
        question
    }
    public enum TiposMensajes
    {
        [Description("¡Registro Guardado!")]
        RegistroGuardado,
        [Description("¡No Se Guardo Su Registro")]
        RegistroNoGuardado,
        [Description("¡No Puede Modificar Un Registro Inexistente!")]
        RegistroInexistente,
        [Description("¡Registro Eliminado Correctamente!")]
        RegistroEliminado,
        [Description("¡Registro Modificado")]
        RegistroModificado,
        [Description("Usuario Existente")]
        UsuarioExistente,
        [Description("¡Registro No Encontrado!")]
        RegistroNoEncontrado,
    }
    public enum TipoTitulo
    {
        [Description("¡Operacion Exitosa!")]
        OperacionExitosa,
        [Description("!Operacion Fallida")]
        OperacionFallida,
        [Description("!Informacion!")]
        Informacion
    }
}
