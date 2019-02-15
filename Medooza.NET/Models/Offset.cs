using System;
using System.Xml.Serialization;

namespace Medooza.NET.Models
{
	[Serializable]
	public class Offset
	{
		[XmlAttribute("start")]
		public long Start { get; set; }

		[XmlAttribute("end")]
		public long End { get; set; }
	}
}