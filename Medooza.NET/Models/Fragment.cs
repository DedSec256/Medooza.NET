using System;
using System.Xml.Serialization;

namespace Medooza.NET.Models
{
	[Serializable]
	public class Fragment
	{
		[XmlElement("offset", typeof(Offset))]
		public Offset[] Offsets { get; set; }

		[XmlAttribute("file")]
		public string File { get; set; }

		[XmlAttribute("line")]
		public long Line { get; set; }

		[XmlAttribute("start")]
		public long Start { get; set; }

		[XmlAttribute("end")]
		public long End { get; set; }
	}
}