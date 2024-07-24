class ChangeStateHelper {
  static buttonAktiviraj_rezervniDijelovi(String status) {
    return status == "idle";
  }

  static buttonServisiraj(String status) {
    return status == "active" || status == "fix" || status == "ready" || status == "task";
  }

  static buttonSpremi(String status) {
    return status == "fix";
  }

  static buttonPosalji(String status) {
    return status == "ready";
  }

  static buttonVrati(String status) {
    return status == "out";
  }

  static buttonDeaktiviraj(String status) {
    return status == "active";
  }

  static buttonRecikliraj(String status) {
    return status == "parts";
  }
}
