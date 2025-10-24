# RendererExtension

Unity に存在している Renderer に機能を拡張するコンポーネントを提供するパッケージです。

## LineRendererWidthMultiplier

LineRenderer による線の太さを変更する機能を提供するコンポーネントです。

Inspector にある Width の項目で設定された線の太さに対して乗算される値を設定することが出来ます。

LineRendererWidthMultiplier には以下の設定項目があります

|設定項目|選択項目|概要|
|:----|:----|:----|
|Mode|Value|Multiplier で設定された値が掛けられます|
| |Scale X|Transform Scale X の値とMultiplierとが掛け合わさった値が掛けられます|
| |Scale Y|Transform Scale Y の値とMultiplierとが掛け合わさった値が掛けられます|
| |Scale Z|Transform Scale Z の値とMultiplierとが掛け合わさった値が掛けられます|
| |Scale Min|Transform Scale の X、Y、 Z の中で最も小さい値とMultiplierとが掛け合わさった値が掛けられます|
| |Scale Max|Transform Scale の X、Y、 Z の中で最も大きい値とMultiplierとが掛け合わさった値が掛けられます|
|Multiplier|-|幅に対して乗算する値<br>Mode が Value 以外の場合でも使用されます|

## LineRendererPositions

LineRenderer の Positions に設定される要素数と各軸の値をシリアライズした Transform の数にしつつ Position の値を設定するコンポーネントです。

コンポーネントを付与した際には、直下の子階層にあるオブジェクトを収集してシリアライズします

LineRenderer の Positions に関する内容は[公式ドキュメント](https://docs.unity3d.com/Manual/class-LineRenderer.html)を参照ください

## TrailRendererCleaner

TrailRenderer の有効、無効を切り替えつつ再利用しようとした場合に、前回引かれていた軌跡が一瞬表示される場合があります。

この症状を抑制する為に、TrailRenderer が無効になった際に軌跡をクリアする機能を提供するコンポーネントです。

コンポーネント事態に設定する項目は存在せず、付与するだけで機能します。