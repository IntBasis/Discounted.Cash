function BlockQuote (el)
  return pandoc.RawBlock('html', '<blockquote class="blockquote">\n  <p>' .. pandoc.utils.stringify(el) .. '</p>\n</blockquote>')
end
