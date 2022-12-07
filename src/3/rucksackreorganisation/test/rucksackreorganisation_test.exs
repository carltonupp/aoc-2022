defmodule RucksackReorganisationTest do
  use ExUnit.Case
  doctest RucksackReorganisation

  test "part 1 sample inputs" do
    samples = [
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw"]

    assert RucksackReorganisation.sum_of_priorites(samples) == 157
  end

  test "split string works" do
    assert elem(RucksackReorganisation.split_string_in_half("vJrwpWtwJgWrhcsFMMfFFhFp"), 0) == "vJrwpWtwJgWr"
    assert elem(RucksackReorganisation.split_string_in_half("vJrwpWtwJgWrhcsFMMfFFhFp"), 1) == "hcsFMMfFFhFp"
  end

  test "overlaps" do
    values = RucksackReorganisation.split_string_in_half("vJrwpWtwJgWrhcsFMMfFFhFp")
    |> RucksackReorganisation.find_overlaps()

    # assert values == [1, 2, 3]
    assert RucksackReorganisation.intersect([1, 2, 3], [2, 3, 4]) == [2, 3]
  end
end
