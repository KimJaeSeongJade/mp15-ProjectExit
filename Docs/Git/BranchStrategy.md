# 브랜치 규칙

브랜치는 두 단계만 씁니다. 9일짜리 프로젝트에 `develop` 까지 두면 절차만 늘고 얻는 것이 없습니다.

```
main
	feature/seunghun_monster-patrol
	feature/yeseul_puzzle-ui
	feature/jaeyoon_player-move
```

| 브랜치 | 역할 | 규칙 |
|---|---|---|
| `main` | 항상 실행 가능한 상태 | <mark>직접 push 금지.</mark> PR로만 들어옵니다 |
| `feature/*` | 기능 작업 | `main` 에서 만들고, 끝나면 PR로 `main` 에 합칩니다 |

---

## 이름 규칙

```
feature/<영문이름>_<작업내용>
```

- 영문이름: 소문자. 누가 하는 작업인지 바로 보이게 합니다.
- 작업내용: **영어 소문자 + 하이픈**. 한국어는 쓰지 않습니다. 환경에 따라 한글 브랜치명이 깨집니다.
- 이름과 작업내용 사이는 언더바로 구분합니다.

```
feature/seunghun_monster-patrol      (O)
feature/yeseul_title-ui              (O)

feature/승훈_몬스터패트롤              (X) 한국어
feature/Seunghun_MonsterPatrol       (X) 대문자, 하이픈 없음
feature/seunghun_work                (X) 내용 불명확
monster-patrol                       (X) feature/ 없음
```

### 팀원 영문 표기

첫날 정해서 아래 표를 채웁니다. 한번 정하면 끝까지 같은 표기를 씁니다.

| 이름 | 영문 표기 |
|---|---|
| 강성현 | (기입) |
| 노승훈 | (기입) |
| 류승민 | (기입) |
| 손예슬 | (기입) |
| 정재윤 | (기입) |

## 브랜치 단위

<mark>기능 하나에 브랜치 하나입니다.</mark>

- 브랜치 하나가 하루 이틀 안에 끝나는 크기가 적당합니다.
- 오래 살아 있는 브랜치는 `main` 과 멀어져서 나중에 충돌이 크게 납니다.
- 작업이 커질 것 같으면 쪼갤 수 있는지 먼저 생각합니다. 예를 들어 "몬스터"를 한 브랜치로 잡지 말고 "패트롤", "시야 감지", "추적" 으로 나눕니다.

## 만들고 지우기

**만들 때**는 반드시 최신 `main` 에서 만듭니다.

1. `main` 으로 이동
2. `Pull origin`
3. `Branch > New Branch`

**지울 때**는 PR이 병합된 직후입니다.

1. GitHub의 PR 화면에서 `Delete branch` (원격)
2. GitHub Desktop에서 `Branch > Delete` (로컬)

## 작업 중 main이 앞서갔다면

내가 작업하는 동안 다른 사람의 PR이 `main` 에 들어가는 일은 자주 있습니다. 작업이 길어졌다면 중간에 한 번 `main` 을 내 브랜치로 가져와 둡니다.

1. `main` 으로 이동 후 `Pull origin`
2. 내 브랜치로 이동
3. `Branch > Merge into current branch` 에서 `main` 선택

이때 충돌이 나면 `ConflictPlaybook.md` 를 봅니다. **나중에 PR에서 한꺼번에 충돌이 나는 것보다 지금 작은 충돌을 푸는 편이 훨씬 쉽습니다.**
