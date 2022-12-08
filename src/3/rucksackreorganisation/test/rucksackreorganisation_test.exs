defmodule RucksackReorganisationTest do
  use ExUnit.Case
  doctest RucksackReorganisation

  test "part 1 sample inputs" do
    assert [ "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw" ]
    |> RucksackReorganisation.sum_of_priorites() == 157
  end

  test "part 1 real inputs" do
    assert Path.expand("./test/inputs.txt")
    |> Path.absname()
    |> File.stream!()
    |> Stream.map(&String.trim_trailing/1)
    |> Enum.to_list()
    |> RucksackReorganisation.sum_of_priorites() == 7875
  end
end
