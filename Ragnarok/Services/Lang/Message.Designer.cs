﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ragnarok.Services.Lang {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Message {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Message() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ragnarok.Services.Lang.Message", typeof(Message).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Este Cnpj já está cadastrado..
        /// </summary>
        public static string MSG_CNPJ_Cadastrado {
            get {
                return ResourceManager.GetString("MSG_CNPJ_Cadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cnpj não é valido..
        /// </summary>
        public static string MSG_CNPJ_Invalido {
            get {
                return ResourceManager.GetString("MSG_CNPJ_Invalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Este Cpf já está cadastrado..
        /// </summary>
        public static string MSG_CPF_Cadastrado {
            get {
                return ResourceManager.GetString("MSG_CPF_Cadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cpf não é valido..
        /// </summary>
        public static string MSG_CPF_Invalido {
            get {
                return ResourceManager.GetString("MSG_CPF_Invalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {0} é obrigatório..
        /// </summary>
        public static string MSG_E_001 {
            get {
                return ResourceManager.GetString("MSG_E_001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {0} não confere com {1}.
        /// </summary>
        public static string MSG_E_002 {
            get {
                return ResourceManager.GetString("MSG_E_002", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registro possui vinculos com outros registro, não pode ser excluído!.
        /// </summary>
        public static string MSG_E_003 {
            get {
                return ResourceManager.GetString("MSG_E_003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é possivel excluir um usúario que está logado..
        /// </summary>
        public static string MSG_E_004 {
            get {
                return ResourceManager.GetString("MSG_E_004", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cadastro alterado com sucesso..
        /// </summary>
        public static string MSG_S_001 {
            get {
                return ResourceManager.GetString("MSG_S_001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cadastro criado com sucesso..
        /// </summary>
        public static string MSG_S_002 {
            get {
                return ResourceManager.GetString("MSG_S_002", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Endereço alterado com sucesso..
        /// </summary>
        public static string MSG_S_003 {
            get {
                return ResourceManager.GetString("MSG_S_003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha reenviada para o funcionário(a)..
        /// </summary>
        public static string MSG_S_004 {
            get {
                return ResourceManager.GetString("MSG_S_004", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registro excluido com sucesso..
        /// </summary>
        public static string MSG_S_005 {
            get {
                return ResourceManager.GetString("MSG_S_005", resourceCulture);
            }
        }
    }
}
