using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IncludeInSchema = false)]
	[System.Serializable]
	public enum ItemsChoiceType
	{
		[XmlEnum("##any:")]
		Item,
		appointment,
		away,
		breakfast,
		busy,
		dinner,
		holiday,
		[XmlEnum("in-transit")]
		intransit,
		[XmlEnum("looking-for-work")]
		lookingforwork,
		meal,
		meeting,
		[XmlEnum("on-the-phone")]
		onthephone,
		other,
		performance,
		[XmlEnum("permanent-absence")]
		permanentabsence,
		playing,
		presentation,
		shopping,
		sleeping,
		spectator,
		steering,
		travel,
		tv,
		unknown,
		vacation,
		working,
		worship
	}
}
