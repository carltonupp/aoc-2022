defmodule RucksackReorganisation do
  @moduledoc """
  Documentation for `RucksackReorganisation`.
  """

  @doc """
  Hello world.

  ## Examples


  """

  def sum_of_priorites rucksacks do
    rucksacks
    |> Enum.map(fn str -> split_string_in_half(str) end)
    |> Enum.map(fn strs -> find_overlaps(strs) end)
    |> Enum.map(fn overlap -> get_char_value(overlap) end)
    |> Enum.sum()
  end

  def sum_of_group_priorities groups do
    groups |> Enum.map(fn group -> calculate_group_priority(group) end) |> Enum.sum()
  end

  defp calculate_group_priority group do
    [ elf1, elf2, elf3 ] = group |> Enum.map(fn elf -> String.graphemes(elf) end)
    intersect(elf1, elf2)
    |> intersect(elf3)
    |> List.first()
    |> get_char_value()
  end

  defp split_string_in_half(str) do
    String.split_at(str, round(String.length(str) / 2))
  end

  defp find_overlaps(substrings) do
    [str1, str2] = substrings
    |> Tuple.to_list()
    |> Enum.map(fn s -> String.graphemes(s) end)

    intersect(str1, str2) |> List.first()
  end

  defp intersect(list1, list2) do
    Enum.filter(list1, fn x -> Enum.member?(list2, x) end)
  end

  defp add_one(n) do
    n + 1
  end

  defp get_char_value(char) do
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    |> String.graphemes()
    |> Enum.find_index(fn c -> c == char end)
    |> add_one()
  end
end
