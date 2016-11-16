using System;

namespace org.doubango.tinyWRAP
{
	public enum tmedia_t140_data_type_t
	{
		tmedia_t140_data_type_utf8,
		tmedia_t140_data_type_zero_width_no_break_space = 15711167,
		tmedia_t140_data_type_backspace = 8,
		tmedia_t140_data_type_esc = 27,
		tmedia_t140_data_type_cr = 13,
		tmedia_t140_data_type_lf = 10,
		tmedia_t140_data_type_cr_lf = 3338,
		tmedia_t140_data_type_interrupt2 = 97,
		tmedia_t140_data_type_bell = 7,
		tmedia_t140_data_type_sos = 152,
		tmedia_t140_data_type_string_term = 156,
		tmedia_t140_data_type_graphic_start = 155,
		tmedia_t140_data_type_graphic_end = 109,
		tmedia_t140_data_type_loss_char_char = 65533,
		tmedia_t140_data_type_loss_utf8 = 15712189
	}
}
