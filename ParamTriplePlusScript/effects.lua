local a = "ParamTriplePlus.Params.AviUtl.EF";
return {
[a .. "Border"] = function(v, ef) 
	obj.effect("縁取り",
	"サイズ", GetValue(ef, "width"),
	"ぼかし", GetValue(ef, "blur"),
	"color", ColorToNumber(GetValue(ef, "color"))) end,
	
[a .. "Shadow"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("シャドー",
	"X", pos.x,
	"Y", pos.y,
	"color", ColorToNumber(GetValue(ef, "color")),
	"濃さ", GetValue(ef, "alpha"),
	"拡散", GetValue(ef, "blur"))
end,

[a .. "Blur"] = function(v, ef) 
	obj.effect("ぼかし", 
	"範囲", GetValue(ef, "blur"),
	"ぼかし", GetValue(ef, "blur"),
	"縦横比", GetValue(ef, "aspect"),
	"光の強さ", GetValue(ef, "light"),
	"サイズ固定", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "BorderBlur"] = function(v, ef) 
	obj.effect("境界ぼかし",
	"範囲", GetValue(ef, "blur"),
	"縦横比", GetValue(ef, "aspect"),
	"透明度の境界をぼかす", BoolToNumber(GetValue(ef, "alphaBorder"))) end,

[a .. "RadioBlur"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("放射ブラー",
	"範囲", GetValue(ef, "blur"),
	"X", pos.x,
	"Y", pos.y,
	"サイズ固定", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "LineBlur"] = function(v, ef)
	obj.effect("方向ブラー",
	"範囲", GetValue(ef, "blur"),
	"角度", GetValue(ef, "angle"),
	"サイズ固定", BoolToNumber(GetValue(ef, "constantSize"))) end,

[a .. "Clipping"] = function(v, ef)
	obj.effect("クリッピング",
	"上", GetValue(ef, "top"),
	"下", GetValue(ef, "bottom"),
	"左", GetValue(ef, "left"),
	"右", GetValue(ef, "right")) end,

[a .. "TendClipping"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("斜めクリッピング",
	"中心X", pos.x,
	"中心Y", pos.y,
	"角度", GetValue(ef, "angle"),
	"ぼかし", GetValue(ef, "blur"),
	"幅", GetValue(ef, "width")) end,

[a .. "Mask"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("マスク",
	"X", pos.x,
	"Y", pos.y,
	"回転", GetValue(ef, "angle"),
	"ぼかし", GetValue(ef, "blur"),
	"サイズ", GetValue(ef, "size"),
	"縦横比", GetValue(ef, "aspect"),
	"type", GetValue(ef, "figure"),
	"マスクの反転", BoolToNumber(GetValue(ef, "flipMask")),
	"元のサイズに合わせる", BoolToNumber(GetValue(ef, "adjustSize"))) end,

[a .. "AdjustColor"] = function(v, ef)
	obj.effect("色調補正",
	"明るさ", GetValue(ef, "brightness"),
	"コントラスト", GetValue(ef, "contrast"),
	"色相", GetValue(ef, "hue"),
	"輝度", GetValue(ef, "value"),
	"彩度", GetValue(ef, "satuation")) end,

[a .. "Gradient"] = function(v, ef)
	local pos = GetValue(ef, "pos")
	obj.effect("グラデーション",
	"中心X", pos.x,
	"中心Y", pos.y,
	"強さ", GetValue(ef, "alpha"),
	"角度", GetValue(ef, "angle"),
	"幅", GetValue(ef, "blur"),
	"color", ColorToNumber(GetValue(ef, "color1")),
	"color2", ColorToNumber(GetValue(ef, "color2"))) end,

[a .. "Colorlize"] = function(v, ef)
	obj.effect("単色化",
	"強さ", GetValue(ef, "alpha"),
	"輝度を保持する", BoolToNumber(GetValue(ef, "holdValue")),
	"color", ColorToNumber(GetValue(ef, "color"))) end,

[a .. "Noise"] = function(v, ef)
	local velocity = GetValue(ef, "velocity")
	local hz = GetValue(ef, "hz")
	obj.effect("ノイズ",
	"強さ", GetValue(ef, "alpha"),
	"速度X", velocity.x,
	"速度Y", velocity.y,
	"変化速度", GetValue(ef, "speed"),
	"周期X", hz.x,
	"周期Y", hz.y,
	"しきい値", GetValue(ef, "threshold"),
	"seed", GetValue(ef, "seed"),
	"mode", GetValue(ef, "mode"),
	"type", GetValue(ef, "type")) end,
	
[a .. "ChromaKey"] = function(v, ef)
	obj.effect("クロマキー",
	"color", ColorToNumber(GetValue(ef, "color")),
	"色相範囲", GetValue(ef, "thres_hue"),
	"彩度範囲", GetValue(ef, "thres_sat"),
	"境界補正", GetValue(ef, "border"),
	"type", GetValue(ef, "type")) end,
	
[a .. "Raster"] = function(v, ef)
	obj.effect("ラスター",
	"横幅", GetValue(ef, "width"),
	"高さ", GetValue(ef, "height"),
	"周期", GetValue(ef, "hz"),
	"縦ラスター", BoolToNumber(GetValue(ef, "vertical")),
	"ランダム周期", BoolToNumber(GetValue(ef, "randomizedHz"))) end,
	
[a .. "PolarCoordinateTransform"] = function(v, ef)
	obj.effect("極座標変換",
	"中心幅", GetValue(ef, "padding"),
	"拡大率", GetValue(ef, "zoom"),
	"回転", GetValue(ef, "rotation"),
	"渦巻", GetValue(ef, "swirl")) end,
	
[a .. "DisplacementMap"] = function(v, ef)
	local delta = GetValue(ef, "delta")
	local pos = GetValue(ef, "pos")
	obj.effect("ディスプレイスメントマップ",
	"param0", delta.x,
	"param1", delta.y,
	"X", pos.x,
	"Y", pos.y,
	"回転", GetValue(ef, "angle"),
	"サイズ", GetValue(ef, "size"),
	"縦横比", GetValue(ef, "aspect"),
	"ぼかし", GetValue(ef, "blur"),
	"元のサイズに合わせる", BoolToNumber(GetValue(ef, "adjustSize")),
	"type", GetValue(ef, "figure"),
	"mode", GetValue(ef, "mode")) end,
}