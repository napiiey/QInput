# QInput

QInput は、複雑な Unity InputSystem を拡張しコードから簡素にアバウトに扱う為のライブラリです。
キーボード、ゲームパッド、マウス、タッチ入力をまとめて簡素に扱えます。
ピンチ入力、フリック入力、方向キー長押し時連打、等も少ない記述で利用できます。

Unity1week や小規模プロダクトを複雑なセットアップをせず早く完成させる事を目的に制作しました。
InputSystem 本来の高度なカスタマイズ性と互換性がない為、大規模プロダクトには向きません。

&nbsp;
## 📦 導入方法

1. Unity のメニューから `Window > Package Manager` を開きます。
2. 左上の `＋` ボタンをクリックし、**[Install package from git URL...]** を選択します。
3. 以下の URL を入力してインストールします。

    ```
    https://github.com/napiiey/QInput.git
    ```

&nbsp;
## 🖋 使い方

### 決定ボタン入力
ゲームパッドの決定ボタン、キーボードのEnterキー・Spaceキーのいずれかが押されている事を確認します。

```csharp
QInput.Ok()
```
使用例
```csharp
if (QInput.Ok())
{
    // 何かをする
}
```

バリエーション
```csharp
QInput.Ok()         // 決定ボタンが押された状態であるか
QInput.OkPressed()  // 決定ボタンがこのフレームに押されたかどうか
QInput.OkReleased() // 決定ボタンがこのフレームに離されたかどうか
```

&nbsp;
### キャンセルボタン入力
ゲームパッドのキャンセルボタン、キーボードのEscapeキーのいずれかが押されている事を確認します。

```csharp
QInput.Cancel()
```

&nbsp;
### クリック入力
マウスのクリック、タッチパッドのタップを確認します。

```csharp
QInput.Click()
```

&nbsp;
### クリック・決定入力
マウスのクリック、タッチパッドのタップ、ゲームパッドの決定ボタン、キーボードのEnterキー・Spaceキーのいずれかが押されている事を確認します。

```csharp
QInput.OkClick()
```

&nbsp;
### 4方向入力
ゲームパッド、スクリーンパッド、キーボードのAWSDキー、矢印キーのいずれかが押されている事を確認します。
```csharp
QInput.Up()    // 上方向が押されているか確認します
QInput.Down()  // 下方向が押されているか確認します
QInput.Left()  // 左方向が押されているか確認します
QInput.Right() // 右方向が押されているか確認します
```
長押し時、自動連打
```csharp
QInput.LeftRepeated()
```

&nbsp;
### 全ての方向入力
ゲームパッドのスティック入力、ゲームパッド、スクリーンパッド、キーボードのAWSDキー、矢印キーの入力をVector2 として取得します。
```csharp
Vector2 direction = QInput.Direction();
```

&nbsp;
### フリック（ドラッグ）入力

タッチスクリーンまたはマウスからフリック（ドラッグ）入力を取得できます。

```csharp
// このフレームでフリックが発生したかどうかを確認します
if (QInput.IsFlicking)
{
    // フリック距離を取得します
    Vector2 flickDistance = QInput.FlickDistance;

    // 何かをする
}
```

&nbsp;
### ピンチイン・ピンチアウト

タッチスクリーンからピンチ入力を取得できます。

```csharp
// ピンチ距離を取得します
float pinchDistance = QInput.PinchUpdate();

// ユーザーがピンチしているかどうかを確認します
if (QInput.IsPinching())
{
    // 何かをする
}
```

