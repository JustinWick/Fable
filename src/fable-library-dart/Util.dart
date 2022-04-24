// ignore_for_file: file_names

// From https://stackoverflow.com/a/37449594
int combineHashCodes(Iterable<int> hashes) =>
    hashes.isEmpty ? 0 : hashes.reduce((h1, h2) => ((h1 << 5) + h1) ^ h2);

bool equalList<T>(List<T> xs, List<T> ys) {
  if (xs.length != ys.length) {
    return false;
  } else {
    if (xs != ys) {
      for (var i = 0; i < xs.length; i++) {
        if (xs[i] != ys[i]) {
          return false;
        }
      }
    }
    return true;
  }
}

// We use dynamic because this is also used for tuples
int compareList(List<dynamic> xs, List<dynamic> ys) {
  if (xs.length != ys.length) {
    return xs.length < ys.length ? -1 : 1;
  }
  for (var i = 0; i < xs.length; i++) {
    final x = xs[i];
    if (x is Comparable) {
      final j = x.compareTo(ys[i]);
      if (j != 0) {
        return j;
      }
    }
  }
  return 0;
}

String int32ToString(int i, [int radix = 10]) {
  if (radix == 10) {
    return i.toString();
  } else {
    i = i < 0 ? 0xFFFFFFFF + i + 1 : i;
    return i.toRadixString(radix);
  }
}