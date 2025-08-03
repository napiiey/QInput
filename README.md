# QInput

QInput は、Unity InputSystem を「簡素に、アバウトに」コードから扱えるようにするライブラリです。
キーボード、ゲームパッド、マウス、タッチ操作をひとまとめに扱え、フリックやピンチ、方向キー長押し時の連打なども、わずかなコードで実現できます。

Unity1Week や小規模プロジェクト向けに、「細かい設定なしで早く実装する」ことを目的として開発されました。
そのため、InputSystem 本来の高いカスタマイズ性や拡張性との互換性はなく、大規模プロダクトには向いていません。

&nbsp;
## 📦 導入方法

1. Unity のメニューから `Window > Package Manager` を開きます。
2. 左上の `＋` ボタンをクリックし、**[Install package from git URL...]** を選択します。
3. 以下の URL を入力してインストールします。

    ```
    https://github.com/napiiey/QInput.git
    ```

&nbsp;
## ✒ 使い方

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

タッチスクリーンから2本指でのピンチ操作を取得できます。

```csharp
// ピンチ距離を取得します
float pinchDistance = QInput.PinchUpdate();

// ユーザーがピンチしているかどうかを確認します
if (QInput.IsPinching())
{
    // 何かをする
}
```

