# 폴더 구조와 에셋 이름

파일을 새로 만들 때 **어디에 넣을지**와 **어떤 이름을 붙일지**에 대한 규칙입니다.

규칙 없이 각자 아무 곳에나 넣으면, 프로젝트가 커질수록 파일을 찾는 데 시간이 걸리고 같은 이름의 에셋이 여러 개 생깁니다. 초기에 구조를 잡는 데는 10분이면 되지만 나중에 정리하는 데는 몇 배가 듭니다.

---

## Assets 폴더 구조

```
Assets/
	Scripts/
		Core/           게임 매니저, 싱글톤, 공통 시스템
		Player/         이동, 체력, 상호작용, 카메라
		Monster/        패트롤, 시야 감지, 추적
		Puzzle/         미션 오브젝트, 완료 판정
		UI/             타이틀, HUD, 팝업, 월드스페이스 표시
		Audio/          사운드 재생 관리
	Scenes/
		Title.unity
		InGame.unity
		Test/           개인 테스트 씬 (빌드 제외)
	Prefabs/
		Player/
		Monster/
		Puzzle/
		UI/
		Environment/
	Materials/
	Animations/
		Player/
		Monster/
	Audio/
		BGM/
		SFX/
	Fonts/
	Imports/            외부에서 받은 에셋
```

- 어디에 둘지 애매한 스크립트는 `Scripts/Core/` 에 둡니다.
- 한 폴더에 파일이 10개를 넘으면 하위 폴더로 나눕니다.
- **개인 이름 폴더를 만들지 않습니다.** `Assets/승훈작업/` 같은 폴더는 나중에 반드시 정리 대상이 됩니다. 테스트 씬만 예외입니다.

## 이름 규칙

- **영어**만 씁니다. 한글 파일명은 환경에 따라 깨집니다.
- **PascalCase**를 기본으로 합니다. (`PlayerController`, `MonsterPatrol`)
- 공백과 하이픈을 쓰지 않습니다. 구분이 필요하면 언더바를 씁니다.
- 에셋 종류를 접두사로 구분합니다.

| 종류 | 접두사 | 예시 |
|---|---|---|
| 스크립트 | 없음 | `PlayerController.cs` |
| 씬 | 없음 | `InGame.unity` |
| 프리팹 | `PFB_` | `PFB_MonsterBasic.prefab` |
| 머티리얼 | `MAT_` | `MAT_PlayerBody.mat` |
| 텍스처 | `TEX_` | `TEX_GroundTile.png` |
| 애니메이션 클립 | `ANIM_` | `ANIM_PlayerRun.anim` |
| 애니메이터 컨트롤러 | `AC_` | `AC_Monster.controller` |
| 배경음 | `BGM_` | `BGM_MainTheme.mp3` |
| 효과음 | `SFX_` | `SFX_PuzzleComplete.wav` |
| 폰트 | `FONT_` | `FONT_MainUI.ttf` |

### 변형이 있을 때

같은 대상의 변형은 접미사로 구분합니다.

```
PFB_Monster_Normal.prefab
PFB_Monster_Fast.prefab

MAT_Player_Default.mat
MAT_Player_Damaged.mat
```

### 나쁜 예시

```
player controller.cs        공백
player-jump.wav             하이픈
pfb_monster.prefab          접두사 소문자
MonsterBasic.prefab         접두사 없음
SFX_퍼즐완료.wav             한국어
test2_final_진짜최종.prefab   무엇인지 알 수 없음
```

## 외부 에셋은 예외

`Assets/Imports/` 안의 파일은 **원본 이름 그대로 둡니다.** 이름을 바꾸면 그 에셋이 내부에서 참조하는 연결이 끊어질 수 있고, 나중에 업데이트를 받을 때도 문제가 됩니다.

## 스크립트 이름

클래스 이름과 파일 이름을 같게 맞춥니다. Unity는 `MonoBehaviour` 를 상속한 스크립트에서 이 둘이 다르면 컴포넌트로 붙지 않습니다.

```
PlayerController.cs  ->  public class PlayerController : MonoBehaviour
```

이름은 **무엇을 하는 것인지 드러나게** 짓습니다.

```
MonsterVision.cs        (O) 몬스터 시야
PuzzleManager.cs        (O) 퍼즐 관리
Test.cs                 (X)
NewBehaviourScript.cs   (X)
Script1.cs              (X)
```
