defmodule RockPaperScissorsTest do
  use ExUnit.Case
  doctest RockPaperScissors

  defp read_file_inputs do
    Path.expand("./test/inputs.txt")
    |> Path.absname()
    |> File.stream!()
    |> Stream.map(&String.trim_trailing/1)
    |> Enum.to_list()
    |> Enum.map(fn x -> String.split(x, " ") |> List.to_tuple() end)
  end

  test "part 1 sample inputs" do
    assert RockPaperScissors.calculate([{ "A", "Y"}, {"B", "X"}, {"C", "Z"}]) == 15
  end

  test "part 1 real inputs" do
    lines = read_file_inputs()
    assert RockPaperScissors.calculate(lines) == 10941
  end

  test "part 2 sample inputs" do
    assert RockPaperScissors.calculate_with_desired_outcomes([{ "A", "Y"}, {"B", "X"}, {"C", "Z"}]) == 12
  end

  test "part 2 real inputs" do
    lines = read_file_inputs()
    assert RockPaperScissors.calculate_with_desired_outcomes(lines) == 13071
  end
end
