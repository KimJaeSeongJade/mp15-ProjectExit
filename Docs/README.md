# Docs

이 폴더는 프로젝트의 규칙과 기록을 모아 두는 곳입니다. 코드로 남지 않는 것, 즉 **어떻게 일할지에 대한 약속**과 **무엇을 왜 그렇게 했는지에 대한 기록**이 여기 쌓입니다.

## 읽는 순서

처음 합류했다면 위에서부터 네 개를 먼저 읽습니다. 나머지는 필요할 때 찾아봅니다.

| 순서 | 문서 | 한글 제목 | 언제 보나 |
|---|---|---|---|
| 1 | `GroundRules.md` | 팀 그라운드룰 | 시작 전 1회. 팀이 지키기로 한 약속 |
| 2 | `Git/DailyWorkflow.md` | 하루 작업 루틴 | 매일 작업 시작 전과 종료 전 |
| 3 | `ProjectSpec.md` | 프로젝트 명세 | 무엇을 만드는지, 누가 무엇을 맡는지 확인할 때 |
| 4 | `Git/CommitConvention.md` | 커밋 메시지 규칙 | 커밋할 때 |
| - | `Git/BranchStrategy.md` | 브랜치 규칙 | 새 작업을 시작할 때 |
| - | `Git/PullRequestGuide.md` | PR 작성과 리뷰 | PR을 올릴 때, 리뷰할 때 |
| - | `Git/ConflictPlaybook.md` | 충돌 대응 | 충돌이 났을 때 |
| - | `Unity/ProjectRules.md` | 유니티 프로젝트 규칙 | 씬·프리팹·에셋을 다룰 때 |
| - | `Unity/FolderStructure.md` | 폴더 구조와 에셋 이름 | 파일을 새로 만들 때 |
| - | `Code/CSharpConvention.md` | C# 코드 규칙 | 스크립트를 작성할 때 |
| - | `AssetCredits.md` | 외부 에셋 출처 | 외부 에셋을 받았을 때 |

## 폴더 구성

```
Docs/
	GroundRules.md
	ProjectSpec.md
	AssetCredits.md
	Git/
	Unity/
	Code/
	Templates/          작업일지·기술문서·PR 양식
	Members/            개인별 폴더
		<이름>/
			WorkLog/    작업일지 (하루 한 개)
			TechDocs/   기술문서 (기능 하나에 한 개)
```

## 시작 전 1회 세팅

아래 네 가지는 작업을 시작하기 전에 한 번만 확인하면 됩니다. 확인하지 않고 작업하면 충돌이 크게 납니다.

1. Unity 2022.3 LTS 로 프로젝트를 엽니다. 다른 버전이면 설정이 바뀝니다.
2. `Edit > Project Settings > Editor` 에서 다음 두 항목을 확인합니다.
	- `Version Control > Mode` 가 `Visible Meta Files` 인지
	- `Asset Serialization > Mode` 가 `Force Text` 인지
3. `Docs/Members/` 에 본인 이름 폴더가 있는지 확인합니다.
4. `GroundRules.md` 와 `Git/DailyWorkflow.md` 를 읽습니다.

## 개인 폴더 사용법

**작업일지**는 하루에 하나씩 `Docs/Members/<이름>/WorkLog/YYYY-MM-DD.md` 로 만듭니다. 양식은 `Templates/WorkLogTemplate.md` 를 복사해서 씁니다. 작성 시점은 그날 작업을 마칠 때이고, 작성한 뒤 커밋까지 하고 마칩니다.

**기술문서**는 맡은 기능 하나가 동작하게 되었을 때 `Docs/Members/<이름>/TechDocs/기능명.md` 로 만듭니다. 양식은 `Templates/TechDocTemplate.md` 입니다. 이 문서들은 발표자료의 재료가 되고, 프로젝트가 끝난 뒤에는 그대로 본인 포트폴리오 자료가 됩니다.

개인 폴더는 본인만 수정합니다. 다른 사람의 폴더는 읽기만 합니다.
