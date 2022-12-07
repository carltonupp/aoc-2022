defmodule RucksackReorganisation do
  @moduledoc """
  Documentation for `RucksackReorganisation`.
  """
alias Supervisor.Default

  @doc """
  Hello world.

  ## Examples


  """

  def split_string_in_half(str) do
    halfway = round(String.length(str) / 2)
    first = String.slice(str, 0..halfway - 1)
    second = String.slice(str, halfway, halfway)
    { first, second }
  end

  def find_overlaps(substrings) do
    {str1, str2} = substrings
    Enum.filter(String.graphemes(str1), fn c -> Enum.member?(String.graphemes(str2), c) end)
    |> Enum.take(1)
  end

  def intersect(list1, list2) do
    Enum.filter(list1, fn x -> Enum.member?(list2, x) end)
  end

  def get_char_value(char) do
    charset = String.graphemes("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    (Enum.find_index(charset, fn c -> c == char end) || 0) + 1
  end

  def sum_of_priorites rucksacks do
    rucksacks
    |> Enum.map(fn str -> split_string_in_half(str) end)
    |> Enum.map(fn strs -> find_overlaps(strs) end)
    |> Enum.flat_map(fn x -> get_char_value(x) end)
    |> Enum.sum()
  end

end
