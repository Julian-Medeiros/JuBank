using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jubank_ATENDIMENTO.jubank.Exceptions
{
	[Serializable]
	public class JuBankException : Exception
	{
		public JuBankException()
		{
		
		}
		public JuBankException(string message) : base($"Erro -> {message}") 
		{
		
		}
		public JuBankException(string message, Exception inner) : base(message, inner) 
		{
		
		}
		protected JuBankException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

