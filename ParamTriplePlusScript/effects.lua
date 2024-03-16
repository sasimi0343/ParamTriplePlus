local a = "ParamTriplePlus.Params.AviUtl.EF";
return {
[a .. "Border"] = function(v, ef) 
	obj.effect("�����",
	"�T�C�Y", GetValue(ef, "width"),
	"�ڂ���", GetValue(ef, "blur"),
	"color", ColorToNumber(GetValue(ef, "color"))) end,
	
[a .. "Shadow"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("�V���h�[",
	"X", pos.x,
	"Y", pos.y,
	"color", ColorToNumber(GetValue(ef, "color")),
	"�Z��", GetValue(ef, "alpha"),
	"�g�U", GetValue(ef, "blur"))
end,

[a .. "Blur"] = function(v, ef) 
	obj.effect("�ڂ���", 
	"�͈�", GetValue(ef, "blur"),
	"�ڂ���", GetValue(ef, "blur"),
	"�c����", GetValue(ef, "aspect"),
	"���̋���", GetValue(ef, "light"),
	"�T�C�Y�Œ�", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "BorderBlur"] = function(v, ef) 
	obj.effect("���E�ڂ���",
	"�͈�", GetValue(ef, "blur"),
	"�c����", GetValue(ef, "aspect"),
	"�����x�̋��E���ڂ���", BoolToNumber(GetValue(ef, "alphaBorder"))) end,

[a .. "RadioBlur"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("���˃u���[",
	"�͈�", GetValue(ef, "blur"),
	"X", pos.x,
	"Y", pos.y,
	"�T�C�Y�Œ�", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "LineBlur"] = function(v, ef)
	obj.effect("�����u���[",
	"�͈�", GetValue(ef, "blur"),
	"�p�x", GetValue(ef, "angle"),
	"�T�C�Y�Œ�", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "Clipping"] = function(v, ef)
	obj.effect("�N���b�s���O",
	"��", GetValue(ef, "top"),
	"��", GetValue(ef, "bottom"),
	"��", GetValue(ef, "left"),
	"�E", GetValue(ef, "right")) end,

[a .. "TendClipping"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("�΂߃N���b�s���O",
	"���SX", pos.x,
	"���SY", pos.y,
	"�p�x", GetValue(ef, "angle"),
	"�ڂ���", GetValue(ef, "blur"),
	"��", GetValue(ef, "width")) end,

[a .. "Mask"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("�}�X�N",
	"X", pos.x,
	"Y", pos.y,
	"��]", GetValue(ef, "angle"),
	"�ڂ���", GetValue(ef, "blur"),
	"�T�C�Y", GetValue(ef, "size"),
	"�c����", GetValue(ef, "aspect"),
	"type", GetValue(ef, "figure"),
	"�}�X�N�̔��]", BoolToNumber(GetValue(ef, "flipMask")),
	"���̃T�C�Y�ɍ��킹��", BoolToNumber(GetValue(ef, "adjustSize"))) end,

[a .. "AdjustColor"] = function(v, ef)
	obj.effect("�F���␳",
	"���邳", GetValue(ef, "brightness"),
	"�R���g���X�g", GetValue(ef, "contrast"),
	"�F��", GetValue(ef, "hue"),
	"�P�x", GetValue(ef, "value"),
	"�ʓx", GetValue(ef, "satuation")) end,

[a .. "Gradient"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("�O���f�[�V����",
	"���SX", pos.x,
	"���SY", pos.y,
	"����", GetValue(ef, "alpha"),
	"�p�x", GetValue(ef, "angle"),
	"��", GetValue(ef, "blur"),
	"color", ColorToNumber(GetValue(ef, "color1")),
	"color2", ColorToNumber(GetValue(ef, "color2"))) end,

[a .. "Colorlize"] = function(v, ef)
	obj.effect("�P�F��",
	"����", GetValue(ef, "alpha"),
	"�P�x��ێ�����", BoolToNumber(GetValue(ef, "holdValue")),
	"color", ColorToNumber(GetValue(ef, "color"))) end,

[a .. "Noise"] = function(v, ef)
	local velocity = GetValue(ef, "velocity")
	local hz = GetValue(ef, "hz")
	obj.effect("�m�C�Y",
	"����", GetValue(ef, "alpha"),
	"���xX", velocity.x,
	"���xY", velocity.y,
	"�ω����x", GetValue(ef, "speed"),
	"����X", hz.x,
	"����Y", hz.y,
	"�������l", GetValue(ef, "threshold"),
	"seed", GetValue(ef, "seed"),
	"mode", GetValue(ef, "mode"),
	"type", GetValue(ef, "type")) end,
	
[a .. "ChromaKey"] = function(v, ef)
	obj.effect("�N���}�L�[",
	"color", ColorToNumber(GetValue(ef, "color")),
	"�F���͈�", GetValue(ef, "thres_hue"),
	"�ʓx�͈�", GetValue(ef, "thres_sat"),
	"���E�␳", GetValue(ef, "border"),
	"type", GetValue(ef, "type")) end,
	
[a .. "Raster"] = function(v, ef)
	obj.effect("���X�^�[",
	"����", GetValue(ef, "width"),
	"����", GetValue(ef, "height"),
	"����", GetValue(ef, "hz"),
	"�c���X�^�[", BoolToNumber(GetValue(ef, "vertical")),
	"�����_������", BoolToNumber(GetValue(ef, "randomizedHz"))) end,
	
[a .. "PolarCoordinateTransform"] = function(v, ef)
	obj.effect("�ɍ��W�ϊ�",
	"���S��", GetValue(ef, "padding"),
	"�g�嗦", GetValue(ef, "zoom"),
	"��]", GetValue(ef, "rotation"),
	"�Q��", GetValue(ef, "swirl")) end,
	
[a .. "DisplacementMap"] = function(v, ef)
	local delta = GetValue(ef, "delta")
	local pos = GetValue(ef, "pos")
	obj.effect("�f�B�X�v���C�X�����g�}�b�v",
	"param0", delta.x,
	"param1", delta.y,
	"X", pos.x,
	"Y", pos.y,
	"��]", GetValue(ef, "angle"),
	"�T�C�Y", GetValue(ef, "size"),
	"�c����", GetValue(ef, "aspect"),
	"�ڂ���", GetValue(ef, "blur"),
	"���̃T�C�Y�ɍ��킹��", BoolToNumber(GetValue(ef, "adjustSize")),
	"type", GetValue(ef, "figure"),
	"mode", GetValue(ef, "mode")) end,
}